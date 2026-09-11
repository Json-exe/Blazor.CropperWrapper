import Cropper from 'cropperjs'

const blobs: string[] = [];

export function initializeCropper(element: HTMLImageElement, options: Cropper.Options, dotnetObjectReference: any) {
    loadStyles();
    element.addEventListener('ready', async () => {
        await dotnetObjectReference.invokeMethodAsync('ReadyEvent');
    });
    element.addEventListener('zoom', async (event) => {
        // @ts-ignore
        await dotnetObjectReference.invokeMethodAsync('ZoomEvent', event.detail);
    });
    element.addEventListener('crop', async (event) => {
        // @ts-ignore
        await dotnetObjectReference.invokeMethodAsync('CropEvent', event.detail);
    });
    return new Cropper(element, options);
}

export function rotateLeft(value: number, cropperReference: Cropper) {
    cropperReference.rotate(value);
}

export function rotateRight(value: number, cropperReference: Cropper) {
    cropperReference.rotate(value);
}

export function rotateTo(value: number, cropperReference: Cropper) {
    cropperReference.rotateTo(value);
}

export function reset(cropperReference: Cropper) {
    cropperReference.reset();
}

export function clear(cropperReference: Cropper) {
    cropperReference.clear();
}

export function move(valueX: number, valueY: number, cropperReference: Cropper) {
    cropperReference.move(valueX, valueY);
}

export function scaleVertically(cropperReference: Cropper) {
    if (cropperReference.getImageData().scaleY === -1) {
        cropperReference.scaleY(1);
    } else {
        cropperReference.scaleY(-1);
    }
}

export function scaleHorizontally(cropperReference: Cropper) {
    if (cropperReference.getImageData().scaleX === -1) {
        cropperReference.scaleX(1);
    } else {
        cropperReference.scaleX(-1);
    }
}

export function getCroppedCanvas(options: Cropper.GetCroppedCanvasOptions, cropperReference: Cropper) {
    const canvas = cropperReference.getCroppedCanvas(options);
    if (!canvas) return null;
    return canvas.toDataURL("image/jpeg");
}

export async function getCroppedCanvasUri(options: Cropper.GetCroppedCanvasOptions, cropperReference: Cropper) {
    const canvas = cropperReference.getCroppedCanvas(options);
    if (!canvas) return null;
    try {
        const blob = await toBlobWrapper(canvas);
        const uri = URL.createObjectURL(blob);
        blobs.push(uri);
        return uri;
    } catch (e) {
        console.error("There was an error creating a blob from the canvas!", e);
        return null;
    }
}

export async function getCroppedCanvasStream(options: Cropper.GetCroppedCanvasOptions, cropperReference: Cropper) {
    const canvas = cropperReference.getCroppedCanvas(options);
    if (!canvas) return null;
    try {
        return await toBlobWrapper(canvas);
    } catch (e) {
        console.error("There was an error creating a blob from the canvas!", e);
        return null;
    }
}

function toBlobWrapper(canvas: HTMLCanvasElement) {
    return new Promise<Blob>((resolve, reject) => {
        canvas.toBlob(blob => {
            if (!blob) {
                reject("Blob could not be created!");
                return;
            }
            resolve(blob);
        }, 'image/jpeg')
    });
}

export function replace(data: string, cropperReference: Cropper) {
    cropperReference.replace(data);
}

export function enable(cropperReference: Cropper) {
    cropperReference.enable();
}

export function disable(cropperReference: Cropper) {
    cropperReference.disable();
}

export function zoom(value: number, cropperReference: Cropper) {
    cropperReference.zoom(value);
}

export function getData(rounded: boolean, cropperReference: Cropper) {
    return cropperReference.getData(rounded);
}

function loadStyles() {
    if (document.querySelector('link[href*="cropper.min.css"]')) return;
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = './_content/Json_exe.Blazor.Cropper/vendors/cropper.min.css';
    document.head.appendChild(link);
}

export function destroyBlobs() {
    for (const blob of blobs) {
        URL.revokeObjectURL(blob);
    }

    blobs.length = 0;
}

export function dispose() {
    destroyBlobs()
}
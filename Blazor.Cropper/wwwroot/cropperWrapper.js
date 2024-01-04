import './vendors/cropper.js'

export function initializeCropper(element, options, dotnetObjectReference) {
    loadStyles();
    const cropper = new Cropper(element, options);
    element.addEventListener('ready', async () => {
        await dotnetObjectReference.invokeMethodAsync('ReadyEvent');
    });
    element.addEventListener('zoom', async (event) => {
        await dotnetObjectReference.invokeMethodAsync('ZoomEvent', event.detail);
    });
    element.addEventListener('crop', async (event) => {
        await dotnetObjectReference.invokeMethodAsync('CropEvent', event.detail);
    });
    return cropper;
}

export function rotateLeft(value, cropperReference) {
    cropperReference.rotate(value);
}

export function rotateRight(value, cropperReference) {
    cropperReference.rotate(value);
}

export function rotateTo(value, cropperReference) {
    cropperReference.rotateTo(value);
}

export function reset(cropperReference) {
    cropperReference.reset();
}

export function clear(cropperReference) {
    cropperReference.clear();
}

export function move(valueX, valueY, cropperReference) {
    cropperReference.move(valueX, valueY);
}

export function scaleVertically(cropperReference) {
    if (cropperReference.getImageData().scaleY === -1) {
        cropperReference.scaleY(1);
    } else {
        cropperReference.scaleY(-1);
    }
}

export function scaleHorizontally(cropperReference) {
    if (cropperReference.getImageData().scaleX === -1) {
        cropperReference.scaleX(1);
    } else {
        cropperReference.scaleX(-1);
    }
}

export function getCroppedCanvas(options, cropperReference) {
    console.log(options);
    const canvas = cropperReference.getCroppedCanvas(options);
    cropperReference.getCroppedCanvas({ fillColor: '' })
    const data = canvas.toDataURL("image/jpeg");
    cropperReference.replace(data);
    return canvas.toDataURL("image/jpeg");
}

export function replace(data, cropperReference) {
    cropperReference.replace(data);
}

export function enable(cropperReference) {
    cropperReference.enable();
}

export function disable(cropperReference) {
    cropperReference.disable();
}

export function zoom(value, cropperReference) {
    cropperReference.zoom(value);
}

export function getData(rounded = false, cropperReference) {
    return cropperReference.getData(rounded);
}

function loadStyles() {
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = './_content/Json_exe.Blazor.Cropper/vendors/cropper.css';
    document.head.appendChild(link);
}
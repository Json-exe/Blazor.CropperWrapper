import './vendors/cropper.js'

export function initializeCropper(element, options) {
    loadStyles();
    return new Cropper(element, options);
}

export function rotateLeft(value, cropperReference) {
    cropperReference.rotate(value);
}

export function rotateRight(value, cropperReference) {
    cropperReference.rotate(value);
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

export function getCroppedCanvas(cropperReference) {
    const canvas = cropperReference.getCroppedCanvas({maxWidth: 4096, maxHeight: 4096});
    const data = canvas.toDataURL("image/jpeg");
    cropperReference.replace(data);
    return canvas.toDataURL("image/jpeg");
}

export function replace(cropperReference, data) {
    cropperReference.replace(data);
}

function loadStyles() {
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = './_content/Json_exe.Blazor.Cropper/vendors/cropper.css';
    document.head.appendChild(link);
}
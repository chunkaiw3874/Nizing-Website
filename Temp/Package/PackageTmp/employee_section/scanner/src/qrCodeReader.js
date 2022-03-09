//const qrcode = window.qrcode;

const video = document.createElement("video");
const canvasElement = document.getElementById("qr-canvas");
const canvas = canvasElement.getContext("2d");

const qrResult = document.getElementById("qr-result");
const outputData = document.getElementById("outputData");
const btnScanQR = document.getElementById("btn-scan-qr");

let scanning = false;

qrcode.callback = res => {
    if (res) {
        outputData.innerText = res;
        scanning = false;

        video.srcObject.getTracks().forEach(track => {
            track.stop();
        });

        qrResult.hidden = false;
        canvasElement.hidden = true;
        btnScanQR.hidden = false;
    }
};

btnScanQR.onclick = () => {
    console.log('btnn clicked');
    navigator.mediaDevices
        .getUserMedia({ video: { facingMode: "environment" } })
        .then(function (stream) {
            console.log('into then...');
            scanning = true;
            console.log('set scanning...');
            qrResult.hidden = true;
            console.log('set qrResult...');
            btnScanQR.hidden = true;
            console.log('set btnScanQR...');
            canvasElement.hidden = false;
            console.log('set canvasElement...');
            video.setAttribute("playsinline", true); // required to tell iOS safari we don't want fullscreen
            console.log('set video attribute...');
            video.srcObject = stream;
            console.log('set video srcObject...');
            video.play();
            console.log('video play...');
            tick();
            console.log('ticking...');
            scan();
            console.log('scanning');
        });
};

function tick() {
    canvasElement.height = video.videoHeight;
    canvasElement.width = video.videoWidth;
    canvas.drawImage(video, 0, 0, canvasElement.width, canvasElement.height);

    scanning && requestAnimationFrame(tick);
}

function scan() {
    try {
        qrcode.decode();
    } catch (e) {
        setTimeout(scan, 300);
    }
}

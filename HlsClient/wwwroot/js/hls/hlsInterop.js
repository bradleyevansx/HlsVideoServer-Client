window.initializeHlsPlayer = (videoElementId, streamUrl) => {
    const videoElement = document.getElementById(videoElementId);
    const hls = new Hls();
    hls.loadSource(streamUrl);
    hls.attachMedia(videoElement);
};

function rndColor() {
    var r = Math.floor(Math.random() * 256);
    var g = Math.floor(Math.random() * 256);
    var b = Math.floor(Math.random() * 256);
    var rgb = 'rgb(' + r + ',' + g + ',' + b + ')';
    var bg_colorB = document.getElementById('bg_color');
    bg_colorB.style.backgroundColor = rgb;
    bg_colorB.onmouseover = function () { rndColor() }
}
window.onload = rndColor;
function onButtonClick(event, arguments) {
    var currentWindow = window;
    var browser = currentWindow.navigator.appCodeName;
    var isBrowserMozilla = (browser === "Mozilla");
    if (isBrowserMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
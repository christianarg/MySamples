
requirejs(["helpers/utilsClass"], function (utils) {
    var u = new utils();
    u.showMessage();
    u.booleanVar = true;
    u.showMessage();
});
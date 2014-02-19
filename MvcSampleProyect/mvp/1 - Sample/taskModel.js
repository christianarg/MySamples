function TaskModel(_text) {
    var id = (new Date()).getTime();
    this.getID = function () {
        return id;
    };
    var text = _text;
    this.getText = function () {
        return text;
    };
    this.setText = function (value) {
        text = value;
    };
}
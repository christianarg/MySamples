/// <reference path="../../Scripts/jquery-2.0.3.js" />

function TaskListPresenter(theView) {
    this.view = theView;

    this.view.addCreateTaskHandler($.proxy(this.addTask, this));
    // Alternativa 2:
    // Solo por instanciar el presentador se muestra la vista
    //this.view.show();
};


TaskListPresenter.prototype = {

    getView: function () {
        return this.view;
    },

    addTask: function (taskTitle) {
        var model = new TaskModel(taskTitle);
        var task = new TaskPresenter(new TaskView());
        task.setModel(model);
        this.view.addTask(task.getView());
    },
    show: function() {
        this.view.show();
    }
};
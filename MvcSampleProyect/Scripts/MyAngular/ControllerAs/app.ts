/// <reference path="../angular.d.ts" />
/// <reference path="../../jqueryui.d.ts" />

var app = angular.module('myHelloWorld', ['ui.bootstrap']);

// Please note that $modalInstance represents a modal window (instance) dependency.
// It is not the same as the $modal service used above.

app.controller('ModalInstanceCtrl', ($scope, $modalInstance, items) => {

    $scope.items = items;
    $scope.selected = {
        item: $scope.items[0]
    };

    $scope.ok = () => {
        $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = () => {
        $modalInstance.dismiss('cancel');
    };
});

class MyController2 {
    $modal;
    items;
    selected;
    $log;

    constructor($modal: ng.ui.bootstrap.IModalService, $log) {
        this.items = ['item1', 'item2', 'item3'];
        this.$modal = $modal;
        this.$log = $log;
    }

    public open(size) {
        var modalInstance = this.$modal.open({
            windowClass: 'draggable',
            backdrop: 'static',
            templateUrl: '/Scripts/MyAngular/myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                items: () => this.items
            }
        });

        setTimeout(() => {

        }, 1000);
        modalInstance.opened.then(() => {
            //$('.modal-dialog').draggable();
            //$('.modal-dialog').draggable({ handle: '.modal-header' });
        });


        modalInstance.result.then(selectedItem => {
            this.selected = selectedItem;
        }, () => {
                this.$log.info('Modal dismissed at: ' + new Date());
            });
    }
}

app.controller('ModalDemoCtrl2', MyController2);

app.controller('AlertDemoCtrl', ($scope) => {
    $scope.alerts = [
        { type: 'danger', msg: 'Oh snap! Change a few things up and try submitting again.' },
        { type: 'success', msg: 'Well done! You successfully read this important alert message.' }
    ];

    $scope.addAlert = () => {
        $scope.alerts.push({ msg: 'Another alert!' });
    };

    $scope.closeAlert = index => {
        $scope.alerts.splice(index, 1);
    };
});
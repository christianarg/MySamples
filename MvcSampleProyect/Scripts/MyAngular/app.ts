/// <reference path="angular.d.ts" />

var app = angular.module('myHelloWorld', ['ui.bootstrap']);

class MyController {
    public helloWorld: string;

    constructor() {
        this.helloWorld = 'helloWorld Paco';
    }
}

app.controller('MyController', MyController);



app.controller('ModalDemoCtrl', ($scope, $modal, $log) => {

    $scope.items = ['item1', 'item2', 'item3'];

    $scope.open = size => {

        var modalInstance = $modal.open({
            templateUrl: '/Scripts/MyAngular/myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                items: () => $scope.items
            }
        });

        modalInstance.result.then(selectedItem => {
            $scope.selected = selectedItem;
        }, () => {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
});

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
/// <reference path="../angular.d.ts" />
/// <reference path="../../scripts/jqueryui.d.ts" />

var app = angular.module('myHelloWorld', ['ui.bootstrap']);

class MyController {
    public helloWorld: string;

    constructor() {
        this.helloWorld = 'helloWorld Paco';
    }
} 


app.directive('draggable', () => {
    return {
        // A = attribute, E = Element, C = Class and M = HTML Comment
        restrict: 'A',
        link(scope, element, attrs) {
            $(element).draggable();
        }
    }
});

app.controller('MyController', MyController);



app.controller('ModalDemoCtrl', ($scope, $modal: ng.ui.bootstrap.IModalService, $log) => {

    alert($scope.tab);
    $scope.items = ['item1', 'item2', 'item3'];

    $scope.open = size => {
        alert($scope.tab);
        var modalInstance = $modal.open({
            windowClass: 'draggable',
            backdrop: 'static',
            templateUrl: '/MyAngular/myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                items: () => $scope.items
            }
        });

        setTimeout(() => {

        }, 1000);
        modalInstance.opened.then(() => {
            //$('.modal-dialog').draggable();
            //$('.modal-dialog').draggable({ handle: '.modal-header' });
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
/// <reference path="angular.d.ts" />
var app = angular.module('myHelloWorld', ['ui.bootstrap']);

var MyController = (function () {
    function MyController() {
        this.helloWorld = 'helloWorld Paco';
    }
    return MyController;
})();

app.controller('MyController', MyController);

app.controller('ModalDemoCtrl', function ($scope, $modal, $log) {
    $scope.items = ['item1', 'item2', 'item3'];

    $scope.open = function (size) {
        var modalInstance = $modal.open({
            templateUrl: '/Scripts/MyAngular/myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                items: function () {
                    return $scope.items;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
});

// Please note that $modalInstance represents a modal window (instance) dependency.
// It is not the same as the $modal service used above.
app.controller('ModalInstanceCtrl', function ($scope, $modalInstance, items) {
    $scope.items = items;
    $scope.selected = {
        item: $scope.items[0]
    };

    $scope.ok = function () {
        $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});

app.controller('AlertDemoCtrl', function ($scope) {
    $scope.alerts = [
        { type: 'danger', msg: 'Oh snap! Change a few things up and try submitting again.' },
        { type: 'success', msg: 'Well done! You successfully read this important alert message.' }
    ];

    $scope.addAlert = function () {
        $scope.alerts.push({ msg: 'Another alert!' });
    };

    $scope.closeAlert = function (index) {
        $scope.alerts.splice(index, 1);
    };
});
//# sourceMappingURL=app.js.map

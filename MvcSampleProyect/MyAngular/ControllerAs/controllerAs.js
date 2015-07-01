/// <reference path="../angular.d.ts" />
/// <reference path="../../scripts/jqueryui.d.ts" />
var app = angular.module('myHelloWorld', ['ui.bootstrap']);
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
var MyController2 = (function () {
    function MyController2($modal, $log) {
        this.items = ['item1', 'item2', 'item3'];
        this.$modal = $modal;
        this.$log = $log;
    }
    MyController2.prototype.open = function (size) {
        var _this = this;
        var modalInstance = this.$modal.open({
            windowClass: 'draggable',
            backdrop: 'static',
            templateUrl: '/MyAngular/myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                items: function () { return _this.items; }
            }
        });
        setTimeout(function () {
        }, 1000);
        modalInstance.opened.then(function () {
            //$('.modal-dialog').draggable();
            //$('.modal-dialog').draggable({ handle: '.modal-header' });
        });
        modalInstance.result.then(function (selectedItem) {
            _this.selected = selectedItem;
        }, function () {
            _this.$log.info('Modal dismissed at: ' + new Date());
        });
    };
    return MyController2;
})();
app.controller('ModalDemoCtrl2', MyController2);
//# sourceMappingURL=controllerAs.js.map
﻿//var app = angular.module('docsSimpleDirective', ['ngRoute']);

angular.module('docsSimpleDirective', [])
  .controller('Ctrl', function ($scope) {
      $scope.customer = {
          name: 'Naomi',
          address: '1600 Amphitheatre'
      };
  })
  .directive('myCustomer', function () {
      return {
          template: 'Name: {{customer.name}} Address: {{customer.address}}'
      };
  });
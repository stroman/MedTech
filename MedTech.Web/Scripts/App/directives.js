angular.module('homeModule').directive('loadingContainer', function () {
    return {
        restrict: 'A',
        scope: false,
        link: function (scope, element, attrs) {
            var loadingLayer = angular.element('<div class="loading"></div>');
            element.append(loadingLayer);
            element.addClass('loading-container');
            $scope.$watch(attrs.loadingContainer, function (value) {
                loadingLayer.toggleClass('ng-hide', !value);
            });
        }
    };
});

homeModule.directive('emailUnique', function () {
    return {
        restrict: 'AE',
        require: 'ngModel',
        link: function ($scope, elem, attrs, ngModel) {
            ngModel.$validators.username = function (modelValue, viewValue) {
                var value = modelValue || viewValue;
                return /^[a-zA-Z0-9]+$/.test(value);
            }
        }
    }
});
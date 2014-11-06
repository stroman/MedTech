adminModule.directive('emailunique', function (userRepository) {
    return {
        require: 'ngModel',
        link: function ($scope, elem, attrs, ngModel) {
            ngModel.$asyncValidators.emailunique = function (modelValue, viewValue) {
                $scope.emailUnique = false;
                return userRepository.checkEmail(viewValue).then(function (data) {
                    $scope.emailUnique = data;
                    return data;
                });
            }
        }
    }
});
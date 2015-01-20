app.controller('tiger', function($scope) {
    var data = {
        name: 'Pesho',
        born: 'Asia',
        birthDate: 2006,
        live: 'Sofia Zoo'
    };

    var picUrl = 'http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg';

    $scope.data = data;
    $scope.picUrl = picUrl;
});
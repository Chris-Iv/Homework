app.controller('studentPage', function($scope) {
    var obj = {
        name: 'Pesho',
        photo: 'http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png',
        grade: 5,
        school: 'High School of Mathematics',
        teacher: 'Ginka Pesheva'
    }
    $scope.obj = obj;
});
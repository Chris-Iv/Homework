app.controller('studentController', function ($scope) {
    var student = {
        "name": "Pesho",
        "grade": 5,
        "photo": "http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png",
        "school": "High School of Mathematics",
        "teacher": "Gichka Pesheva"
    };

    $scope.student = student;
});

app.controller('bindImageController', function ($scope) {
    var imgUrl = 'http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png';
    $scope.imgUrl = imgUrl;
});
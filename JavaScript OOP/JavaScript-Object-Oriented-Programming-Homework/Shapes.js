var Shape = (function Shape() {
    function Shape(x, y, color) {
        this._x = x;
        this._y = y;
        this._color = color;
    }

    Shape.prototype.getX = function() {
        return this._x;
    };

    Shape.prototype.getColor = function() {
        return this._color;
    };

    Shape.prototype.toString = function() {
        var result = this.constructor.name + " - " +
            "X: " + this._x +
            ", Y: " + this._y +
            ", Color: " + this._color;
        return result;
    };

    Shape.prototype.canvas = function() {
        var canvas = {
            element: document.getElementById("shapesContainer").getContext("2d")
        };

        return canvas;
    };

    return Shape;
})();

var Circle = (function Circle() {
    function Circle(x, y, color, radius) {
        Shape.call(this, x, y, color);
        this._radius = radius;
    }

    Circle.prototype = Object.create(Shape.prototype);
    Circle.prototype.constructor = Circle;

    Circle.prototype.getRadius = function() {
        return this._radius;
    };

    Circle.prototype.toString = function () {
        var result = Shape.prototype.toString.call(this) +
            ', Radius: ' + this._radius;
        return result;
    };

    Circle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.arc(this._x, this._y, this._radius, 0, 2 * Math.PI, false);
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fill();
        this.canvas().element.stroke();
    };

    return Circle;
})();

var Rectangle = (function Rectangle() {
    function Rectangle(x, y, color, width, height) {
        Shape.call(this, x, y, color);
        this._width = width;
        this._height = height;
    }

    Rectangle.prototype = Object.create(Shape.prototype);
    Rectangle.prototype.constructor = Rectangle;

    Rectangle.prototype.getWidth = function () {
        return this._width;
    };

    Rectangle.prototype.getHeight = function () {
        return this._height;
    };

    Rectangle.prototype.toString = function () {
        var result = Shape.prototype.toString.call(this) +
            ', Width: ' + this._width +
            ', Height: ' + this._height;
        return result;
    };

    Rectangle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fillRect(this._x, this._y, this._width, this._height);
    };

    return Rectangle;
})();

var Point = (function Point() {
    function Point(x, y, color) {
        Shape.call(this, x, y, color);
    }

    Point.prototype = Object.create(Shape.prototype);
    Point.prototype.constructor = Point;

    Point.prototype.toString = function() {
        return Shape.prototype.toString.call(this);
    };

    Point.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fillRect(this._x, this._y, 3, 3);
    };

    return Point;
})();

var Triangle = (function Triangle() {
    function Triangle(point1, point2, point3, color) {
        Shape.call(this, point1._x, point1._y, color);
        this._point2 = point2;
        this._point3 = point3;
    }

    Triangle.prototype = Object.create(Shape.prototype);
    Triangle.prototype.constructor = Triangle;

    Triangle.prototype.getPoint1 = function () {
        return this._point1;
    };

    Triangle.prototype.getPoint2 = function () {
        return this._point2;
    };

    Triangle.prototype.getPoint3 = function () {
        return this._point3;
    };

    Triangle.prototype.toString = function () {
        var result = Shape.prototype.toString.call(this) +
            ', X2: ' + this._p2._x +
            ', Y2: ' + this._p2._y +
            ', X3: ' + this._p3._x +
            ', Y3: ' + this._p3._y;
        return result;
    };

    Triangle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.moveTo(this._x, this._y);
        this.canvas().element.lineTo(this._x2 + this._x, this._y2 + this._y);
        this.canvas().element.lineTo(this._x3 + this._x, this._y3 + this._y);
        this.canvas().element.fill();
    };

    return Triangle;
})();

var Segment = (function Segment() {
    function Segment(point1, point2, color) {
        Shape.call(this, point1._x, point1._y, color);
        this._point2 = point2;
    }

    Segment.prototype = Object.create(Shape.prototype);
    Segment.prototype.constructor = Segment;

    Segment.prototype.getPoint2 = function () {
        return this._point2;
    };

    Segment.prototype.toString = function () {
        var result = Shape.prototype.toString.call(this) +
            ', X2: ' + this._p2._x +
            ', Y2: ' + this._p2._y;
        return result;
    };

    Segment.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.moveTo(this._x, this._y);
        this.canvas().element.lineTo(this._x2 + this._x, this._x2 + this._y);
        this.canvas().element.strokeStyle = this._color;
        this.canvas().element.stroke();
    };

    return Segment;
})();
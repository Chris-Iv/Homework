var Question = (function () {
    var Question = function Question(id) {
        this_id = id;
    };

    Question.prototype.setTrueAnswer = function (trueAnswerId) {
        this._trueAnswerId = trueAnswerId;
    };

    Question.prototype.saveUserAnswer = function (userAnswerId) {
        this._userAnswerId = userAnswerId;
        localStorage.setItem(this._id, userAnswerId);
    };

    Question.prototype.loadUserAnswer = function () {
        if(localStorage[this._id]){
            this._userAnswerId = localStorage[this._id];
            $('#' + this._userAnswerId).attr('checked', true);
        }
    };

    Question.prototype.showTrueAnswer = function () {
        $('#' + this._trueAnswerId + '+ label').css('background', 'greenyellow');
    };

    Question.prototype.emptyStorage = function () {
        delete localStorage[this._id];
    };

    return Question;
}());
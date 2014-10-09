function reverseWordsInString(str) {
    var result = '';
    var words = str.split(' ');
    for (var i = 0; i < words.length; i++) {
        result += words[i].split('').reverse().join('') + ' ';
    }
    console.log(result);
}
reverseWordsInString('Hello, how are you.');
reverseWordsInString('Life is pretty good, isn’t it?');
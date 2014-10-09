function findCardFrequency(input) {
    var result = "";

    function onlyUnique(value, index, self) {
        return self.indexOf(value) === index;
    }
    var cards = input.split(/[♥♣♦♠ ]+/);
    var length = cards.length - 1;
    var unique = cards.filter(onlyUnique);
    cards.sort();
    var cardsFreq = {};
    var count = 1;
    for (var i = 1; i < cards.length; i++) {
        if (cards[i] === cards[i - 1]) {
            count++;
            cardsFreq[cards[i]] = count;
        } else {
            cardsFreq[cards[i]] = 1;
            count = 1;
        }

    }
    for (var l = 0; l < unique.length; l++) {
        var currentCard = unique[l];
        for (var card in cardsFreq) {
            if (card === currentCard) {
                result += card + " -> " + ((cardsFreq[card] * 100) / length).toFixed(2) + "% " + "\n";
            }
        }

    }
    console.log(result);
}
findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findCardFrequency('10♣ 10♥');
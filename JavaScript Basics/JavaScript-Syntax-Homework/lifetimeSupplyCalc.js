function calcSupply(age,maxAge,food) {
    var days = (maxAge - age) * 365;
    var kg = days * food;
    console.log(kg + "kg of chocolate would be enough until I am " + maxAge + " years old.");
}
calcSupply(38,118,0.5);
calcSupply(20,87,2);
calcSupply(16,102,1.1);
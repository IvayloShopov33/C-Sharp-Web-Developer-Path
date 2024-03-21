function solve(catsDetails) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (let i = 0; i < catsDetails.length; i++) {
        const [catName, catAge] = catsDetails[i].split(' ');
        const cat = new Cat(catName, catAge);
        cat.meow();
    }
}

solve(['Mellow 2', 'Tom 5']);
solve(['Candy 1', 'Poppy 3', 'Nyx 2']);
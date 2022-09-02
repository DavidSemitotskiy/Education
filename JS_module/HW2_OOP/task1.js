class Shape{
  getArea(){}
}

class Square extends Shape{
  constructor(side){
    super();
    this.side = side;
  }

  getArea(){
    return this.side * this.side;
  }
}

class Circle extends Shape{
  constructor(radius){
    super();
    this.radius = radius;
  }

  getArea(){
    return Math.PI * (this.radius * this.radius);
  }
}

console.log("TASK1")
let circle = new Circle(3);
console.log(circle.getArea());
let square = new Square(6);
console.log(square.getArea());
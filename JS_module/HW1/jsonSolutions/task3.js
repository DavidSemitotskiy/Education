const randomNumber = Math.floor(Math.random() * (20 - 1)) + 1;
while (true)
{
  let userNumber = +prompt("Input Number"); 
  if (userNumber == randomNumber)
  {
    alert("You picked correct number!!!");
    break;
  }
  else if (userNumber > randomNumber)
  {
    alert("Hidden number is lower than inputted one");
  }
  else
  {
    alert("Hidden number is bigger than inputted one");
  }
}
let startYear = 2014;
while (startYear <= 2050)
{
  let date = new Date(startYear, 1, 1);
  if (date.getDay() == 0)
  {
    console.log(startYear);
  }

  startYear++;
}
function addSymbolsToStr(str)
{
  if (str.startsWith("Py"))
  {
    return str;
  }

  return str.replace(str, "Py" + str);
}

let inputtedString = prompt("Input string");
alert(addSymbolsToStr(inputtedString));
import React, { useState } from 'react';
import { Input } from 'reactstrap';

function Calculator() {
  const [mathExpression, setMathExpression] = useState('');
  const [mathResult, setMathResult] = useState('');
  const [errorMessage, setErrorMessage] = useState('');
  
  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(mathExpression)
  };

  function handleChange (event) {
    setMathExpression(event.target.value)
  }

  async function handleCalculation () {
    const response = await fetch('calculator', requestOptions);
    debugger;
    const data = await response.json();
    debugger;

    if (response.status ==  200) {
      setErrorMessage('');
      setMathResult(data.value);
    }
    else {
      setErrorMessage(data.detail ?? data.value);
      setMathResult(0);
    }
  }

  return (
    <div id="1">
      <h1>Calculator</h1>

      <Input onChange={handleChange} value={mathExpression}></Input>
      <p style={{color: 'red'}}>{errorMessage}</p>
      
      <button className="btn btn-primary" onClick={handleCalculation}>Calculate</button>

      <h3>Result = {mathResult}</h3>
    </div>
  );
}

export default Calculator;
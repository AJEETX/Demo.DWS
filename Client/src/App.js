import React, { Component } from 'react';
import Dropzone from 'react-dropzone';
import csv from 'csv';
const url='http://localhost:5001/api/UnitPrice';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
        units: []
    }
    this.Top = this.Top.bind(this);
    this.Bottom = this.Bottom.bind(this);
 };

  Top() {

    fetch(url+'/mostexpensive', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      }
    }).then(res => res.json())
    .then((data) => {
      this.setState({ units: data });
    })
 }
 Bottom() {

  fetch(url+'/leastexpensive', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
    }
  }).then(res => res.json())
  .then((data) => {
    this.setState({ units: data });
  })
}
  onDrop(files) {
    this.setState({ files });
    var file = files[0];
    const reader = new FileReader();
    reader.onload = () => {
      csv.parse(reader.result, (err, data) => {
        var requests = [];
        for (var i = 0; i < data.length; i++) {
          const unitID = data[i][0];
          const date = data[i][1];
          const unitPrice = data[i][2];
          const request = { "unitID": unitID,"date": date, "unitPrice": unitPrice };
          requests.push(request);
        };
          fetch(url, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(requests)
          }).then(res => res.json())
          .then((data) => {
            console.log(data);
            this.setState({ units: data });
          })
      });
    };
    reader.readAsBinaryString(file);
  }
  render() {
    const fontSize = 5;
    let response = this.state.units;
    return (
      <div align="center" >
        <br /><br /><br />
        <div className="dropzone">
          <Dropzone accept=".csv" onDropAccepted={this.onDrop.bind(this)}>            
          </Dropzone>
        </div>
        <h2>Upload or drop your <font size={fontSize} color="#00A4FF">CSV</font> file above in the box.</h2>
        <button onClick = {this.Bottom}>5 Least expensive</button> &nbsp;
        <button onClick = {this.Top}>5 Most expensive</button>
        { response && 
        <table>
        <thead>
          <tr>
            <th>UnitPrice</th>
          </tr>
        </thead>
        <tbody>
          {response.map((unit, index) =>
            <tr key={unit.ID}>
            <td>{unit.unitPrice}</td>
            </tr>
            )}
        </tbody>
        </table>
        }
      </div>
    )
  }
}
export default App;
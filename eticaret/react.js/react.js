class App extends Component {
    state = { counter: 0 }
    render() {
      return (
        <div className="App">
          <button onClick={() => {this.setState({ counter: this.state.counter + 1 })}}>
              Artır  
          </button>
          
          <h2>{this.state.counter}</h2>
          <h1>{this.state.counter}</h1>
          <div id="myDiv">{this.state.counter}</div>
          <div id="yourDiv">{this.state.counter}</div>
          
          <button onClick={() => {this.setState({ counter: this.state.counter - 1 })
          }}>
            Azalt
          </button>
        </div>
      );
    }
  }
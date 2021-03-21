import logo from './logo.svg';
import './App.css';
import { Home } from './Pages/Home';
import { Addresses } from './Pages/Addresses';
import { Navigation } from './Components/Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <div>
      <BrowserRouter>
        <Navigation/>

        <Switch>
          <Route path='/' component={Home} exact/>
          <Route path='/addresses' component={Addresses}/>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;

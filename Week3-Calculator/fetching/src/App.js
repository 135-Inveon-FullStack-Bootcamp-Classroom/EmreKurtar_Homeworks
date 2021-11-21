import './App.css';
import Container from './Components/Container'
import { WeatherProvider } from './Context/WeatherContext';

function App() {
  return (
    
        <WeatherProvider>
          <Container/>
        </WeatherProvider>
  );
}

export default App;

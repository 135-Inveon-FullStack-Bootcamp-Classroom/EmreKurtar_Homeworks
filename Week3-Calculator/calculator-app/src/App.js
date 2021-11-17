import "./App.css";
import AppContainer from "./components/AppContainer";
import TopHeader from "./components/TopHeader";
import ScreenSection from "./components/ScreenSection";
import KeysSection from "./components/KeysSection";

function App() {
  return (
    <AppContainer>
      <TopHeader />
      <ScreenSection />
      <KeysSection />
    </AppContainer>
  );
}

export default App;

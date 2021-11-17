import { useContext } from "react";
import { CalcContext } from "../context/CalContext";

const styles = {
  screenSection: {
    width: "100%",
    height: "30%",
    display: "flex",
    justifyContent: "center",
    flexDirection: "column",
    alignItems: "flex-end",
    fontFamily: "arial",
  },
  mainText: {
    color: "#fff",
    fontSize: 40,
    padding: 10,
  },
  caption: {
    color: "#999",
    fontSize: 13,
    paddingRight: 10,
  },
};

const ScreenSection = () => {
  const {history, mainText } = useContext(CalcContext);

  const renderCaption = () => {
      return (
        <span style={styles.caption}>
          
          {history}
        </span>
      );
  };

  return (
    <div style={styles.screenSection}>
      {renderCaption()}
      <span style={styles.mainText}>{mainText}</span>
    </div>
  );
};

export default ScreenSection;
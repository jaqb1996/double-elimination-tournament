const PopUpContestant = (props) => {
  const { score, name, handleChange, id } = props;
  return (
    <div className="popup-contestant">
      <span className="popup-contestant-name">{name}</span>
      <input
        className="popup-contestant-score"
        id={id}
        value={score}
        onChange={handleChange}
        spellCheck="false"
      />
    </div>
  );
};

export default PopUpContestant;

const useDataCheck = (compnent, data) => {
  if (data) {
    return compnent;
  }
  return (
    <div className="loader-container">
      <div className="loader"></div>
    </div>
  );
};

export default useDataCheck;

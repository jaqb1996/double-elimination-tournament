const PageNotFound = () => {
  return (
    <div className="error-404">
      <span className="error-404--badge">404</span>
      <br />
      <span className="error-404--text">Ops... Page not found </span>
      <span className="error-404--description">
        We're sorry, but we can't find the page you were looking for. Probably
        you entered the wrong id of the tournament. Try with another tournament
        id.
      </span>
    </div>
  );
};

export default PageNotFound;

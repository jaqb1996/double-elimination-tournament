export const ACTIONS = {
  FETCH_DATA: "fetch-data",
  SUCCESS: "success",
  PAGE_NOT_FOUND: "page-not-found",
  ERROR: "error",
  UPDATE_SCORE: "update-score",
};

export const initialState = {
  tournamentData: "",
  loading: true,
  pageNotFound: false,
  error: null,
};

const tournamentDataReducer = (state, action) => {
  switch (action.type) {
    case ACTIONS.FETCH_DATA: {
      return {
        ...state,
      };
    }
    case ACTIONS.SUCCESS: {
      return {
        ...state,
        loading: false,
        tournamentData: action.data,
      };
    }
    case ACTIONS.PAGE_NOT_FOUND: {
      return {
        ...state,
        pageNotFound: true,
      };
    }
    case ACTIONS.ERROR: {
      return {
        ...state,
        error: action.error,
      };
    }
    case ACTIONS.UPDATE_SCORE: {
      return {
        ...state,
        tournamentData: action.data,
      };
    }
    default:
      return state;
  }
};

export default tournamentDataReducer;

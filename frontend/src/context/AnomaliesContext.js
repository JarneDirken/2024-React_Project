// AnomaliesContext.js

import React, { createContext, useContext, useState } from 'react';
import AnomalyTrackerApi from '../apis/anomalytrackerapi';

const AnomaliesContext = createContext();

export const AnomaliesProvider = ({ children }) => {
  const [anomalies, setAnomalies] = useState([]);

  const updateAnomaly = (id, updatedData) => {
    AnomalyTrackerApi.updateAnomaly(id, updatedData)
      .then(response => {
        // Handle the successful response if needed
        console.log("Anomaly updated successfully:", response.data);

        // Update the local state with the updated anomaly data
        setAnomalies((prevAnomalies) =>
          prevAnomalies.map((anomaly) =>
            anomaly.id === id ? { ...anomaly, ...updatedData } : anomaly
          )
        );
      })
      .catch(error => {
        // Handle errors, such as network issues or server errors
        console.error("Error updating anomaly:", error);
      });
  };

  return (
    <AnomaliesContext.Provider value={{ anomalies, updateAnomaly }}>
      {children}
    </AnomaliesContext.Provider>
  );
};

export const useAnomalies = () => {
  return useContext(AnomaliesContext);
};

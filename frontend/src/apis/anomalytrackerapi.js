import configData from '../config/config.json';
import axios from 'axios';

const anomalyTrackerBaseUrl = configData.anomalytrackerapi + "api/anomaly";
const anomalyTrackerAssetUrl = configData.anomalytrackerapi + "api/asset";
const apiHeader = configData.ApiHeader;
const apiKey = configData.ApiKey;

class AnomalyTrackerApi {
    //AnomalyMapping
    static getAnomalies(){
        return axios.get(anomalyTrackerBaseUrl, {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
    static getAnomaly(id){
        return axios.get(anomalyTrackerBaseUrl + "/" + id, {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
    static getAnomalyTypes(){
        return axios.get(anomalyTrackerBaseUrl + "/anomalytypes", {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
    static getSeverityEnumerations(){
        return axios.get(anomalyTrackerBaseUrl + "/enum/severity", {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
    static getAnomaliesFiltered(anomalyTypes, anomalyStatus, selectedFlag, selectedSeverities, selectedStartDate, selectedEndDate, selectedDateSorting) {
        const anomalyTypesString = anomalyTypes.join(',');
        const selectedSeveritiesString = selectedSeverities.join(',');
        return axios.get(anomalyTrackerBaseUrl + `/filteranomaly?anomalyTypes=${anomalyTypesString}&anomalyStatus=${anomalyStatus}&selectedFlag=${selectedFlag}&selectedSeverities=${selectedSeveritiesString}&selectedStartDate=${selectedStartDate}&selectedEndDate=${selectedEndDate}&selectedDateSorting=${selectedDateSorting}`, {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
     
    static updateAnomaly(id, updateAnomalyDto) {
        return axios.patch(`${anomalyTrackerBaseUrl}/${id}`, updateAnomalyDto, {
            headers: {
                [apiHeader]: apiKey
            }
        })
    }    

    //AssetMapping
    static getAssets(){
        return axios.get(anomalyTrackerAssetUrl, {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
    static getAsset(id){
        return axios.get(anomalyTrackerAssetUrl + "/" + id, {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
    static getAssetTypes(){
        return axios.get(anomalyTrackerAssetUrl + "/assettypes", {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }

    static updateAsset(id, updateAssetDto) {
        return axios.patch(`${anomalyTrackerAssetUrl}/${id}`, updateAssetDto, {
            headers: {
                [apiHeader]: apiKey
            }
        })
    }    
    static getAssetsFiltered(assetTypes, selectedFlag, selectedStartDate, selectedEndDate, selectedAssetDateSorting) {
        const assetTypesString = assetTypes.join(',');
        return axios.get(anomalyTrackerAssetUrl + `/filterasset?assetTypes=${assetTypesString}&selectedFlag=${selectedFlag}&selectedStartDate=${selectedStartDate}&selectedEndDate=${selectedEndDate}&selectedAssetDateSorting=${selectedAssetDateSorting}`, {
            headers: {
                [apiHeader]: apiKey
            }
        });
    }
}

export default AnomalyTrackerApi;
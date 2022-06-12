import axios from "axios";
import { getApiUrl } from "./Configuration";

export type DataInfo = {
  uuid: string;
};
export class TApi {

  constructor(private url: string) { }
  public getTest(text: string) {
    return axios.get<string>(
      `${this.url}/api/Test/Get?text=${text}`
    )
  }
}
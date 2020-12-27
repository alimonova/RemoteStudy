import fetchData, { IfetchDataParams } from "../fetchData"
import { ICourse } from "./interfaces"

interface IServData extends IfetchDataParams {
  data: ICourse[]
}

// вход в акканут
export default async function getData(): Promise<IServData> {
  return await fetchData("courses")
}

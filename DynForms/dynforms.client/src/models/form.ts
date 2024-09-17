import { Field } from "./form-field";

export interface Form {
  id: number,
  name: string,
  displayName: string,
  enabled: boolean,
  fields: Field[]
}


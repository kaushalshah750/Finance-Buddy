import { Banks } from "./Banks"
import { UserDetails } from "./UserDetails"

export interface Loans{
    Id: number
    Name: string
    Bank: Banks
    Amount: number
    Monthly_Emi: number
    AddedBy_UId: UserDetails
    CreatedDate: Date
    UpdatedDate: Date
}
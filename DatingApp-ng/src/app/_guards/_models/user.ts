import { ILog } from './_interfaces/ILog';
import { IAddress } from './_interfaces/IAddress';
import { Photo } from './photo';

export class User implements ILog,IAddress{
  id:number;
  username:string;
  password:string;
  knownAs:string;
  age:number;
  gender:number;
  photoUrl:string;
  introduction?:string;
  interests?:string;
  photos?: Photo[];
  // Contracts -----------
  area: string;
  city: string;
  country: string;
  createdAt: Date;
  houseNo: string;
  lastActive: Date;
  roadNo: string;
  updatedAt: Date;
  zip: string;


}

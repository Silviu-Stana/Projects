import { User } from './User';
import { Company } from './Company';
/// <reference types="@types/google.maps" />
import { CustomMap } from './CustomMap';

const user = new User();
const company = new Company();
const map = new CustomMap('map');
map.addMarker(user);
map.addMarker(company);

import { Component, OnInit } from '@angular/core';
import { RentService } from '../../../services/rent/rent.service';
import { VehicleModule } from '../../../models/vehicle.model';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { VehicleTypeService } from '../../../services/vehicle-type/vehicle-type.service';
import { VehicleValidations } from '../../../models/validations/validationModels';

@Component({
  selector: 'app-edit-rent',
  templateUrl: './edit-rent.component.html',
  styleUrls: ['./edit-rent.component.css']
})
export class EditRentComponent implements OnInit {

  vehicle:any
  id:any
  types: any = [];
  validations: VehicleValidations = new VehicleValidations();
  vehicleLoaded: boolean;

  constructor(private rentService: RentService, private route: ActivatedRoute, private router: Router, private vehicleTypeService: VehicleTypeService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['Id'];

        this.vehicle = this.rentService.getVehicle(this.id).
          subscribe(data => {
            this.vehicleLoaded = true
            this.vehicle = data
         })
    });    
    this.vehicleTypeService.getTypes().subscribe(data => {
      this.types = data;
    })
  }

  onSubmit(editVehicleData: VehicleModule, form: NgForm) {
    if(this.validations.validateEdit(editVehicleData)) return;
    editVehicleData.Id = this.id  
    this.rentService.editVehicle(this.id, editVehicleData)
    .subscribe( data => {
      alert("Edit was successful!");
    },
    error => {
      alert("Error!");
    })
  }
}

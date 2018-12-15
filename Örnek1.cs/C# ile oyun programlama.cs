import { Component, OnInit } from '@angular/core';
import _ from "lodash";
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
 
  ngOnInit() {
    var vm = new VehicleManager();
 
    var warMachine = new WarMachine(25);
    var warMachineDecorator = new WarMachineDecorator(warMachine)
    var plane = new Plan(warMachineDecorator, 0, 15);
    var helicopter = new Helicopter(warMachineDecorator, 40, 30);
 
    vm.Add(warMachine, "WarMachine");
    vm.Add(warMachineDecorator, "WarMachineDecorator");
    vm.Add(plane, "Plane");
    vm.Add(helicopter, "Helicopter");
    
 
    let newWarMachine = vm.GetCloneVehicle("WarMachine");
    newWarMachine.Fire();
    newWarMachine.MoveForward();
 
    let newWarMachineDecorator = vm.GetCloneVehicle("WarMachineDecorator");
    newWarMachineDecorator.Fire();
    newWarMachineDecorator.Escape();
    newWarMachineDecorator.MoveForward();
 
    let newPlane = vm.GetCloneVehicle("Plane");
    newPlane.MoveDown();
    newPlane.MoveUp();
    newPlane.Fire();
    newPlane.Escape();
    newPlane.Stop();
 
    let newHelicopter = vm.GetCloneVehicle("Helicopter");    
    newHelicopter.MoveForward();
    newHelicopter.Fire();
    newHelicopter.Escape();
 
  }
}
 
export abstract class Vehicle {
  public abstract Fire();
  public abstract MoveForward()
}
 
export class WarMachine extends Vehicle {
  protected _width: number;
  protected _height: number;
 
  protected _left: number;
  constructor(left: number) {
    super();
    this._left = left;
  }
 
  public Fire() { console.log("Fire WarMachine"); }
  public MoveForward() { }
}
 
abstract class VehicleDecorator extends Vehicle {
  protected _vehicle: Vehicle;
  constructor(vehicle: Vehicle) {
    super();
    this._vehicle = vehicle;
  }
  public Fire() {
    if (this._vehicle != null)
      this._vehicle.Fire();
  }
  public MoveForward() {
    if (this._vehicle != null) {
      this._vehicle.MoveForward();
    }
  }
}
 
export class WarMachineDecorator extends VehicleDecorator {
  constructor(vehicle: Vehicle) {
    super(vehicle);
  }
  public Fire() {
    if (this._vehicle != null) {
      this._vehicle.Fire();
    }
  }
  public MoveForward() {
    if (this._vehicle != null) {
      this._vehicle.MoveForward();
    }
  }
  public Escape() {
    for (var i = 0; i < 3; i++) {
      this.MoveForward();
    }
  }
  public Stop() { }
}
 
export class Plan extends WarMachineDecorator {
  protected _speed: number;
  protected _top: number;
  protected _left: number;
 
  constructor(vehicle: Vehicle, top: number, speed: number) {
    super(vehicle);
    this._top = top;
    this._top = speed;
  }
  public Fire() {
    if (this._vehicle != null) {
      this._vehicle.Fire();
    }
  }
  public MoveForward() {
    if (this._vehicle != null) {
      this._vehicle.MoveForward();
    }
  }
 
  public MoveBack() { }
  public MoveUp() { }
  public MoveDown() { }
}
 
export class Helicopter extends WarMachineDecorator {
  protected _top: number;
 
  constructor(vehicle: Vehicle, top: number, speed: number) {
    super(vehicle);
    this._top = top;
  }
  public Fire() {
    if (this._vehicle != null) {
      this._vehicle.Fire();
    }
  }
  public MoveForward() {
    if (this._vehicle != null) {
      this._vehicle.MoveForward();
    }
  }
}
 
export class VehicleManager {
 
  public VehicleObjects: Map<string, Vehicle>;
  constructor() {
    this.VehicleObjects = new Map<string, Vehicle>();
  }
 
  public Add(item: Vehicle, name: string) {
    this.VehicleObjects.set(name, item);
  }
 
  public GetCloneVehicle(name: string) {
    if (this.VehicleObjects.has(name)) {
      return _.cloneDeep(this.VehicleObjects.get(name));
    }
  }
}
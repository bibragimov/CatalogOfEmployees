import { Component, OnInit, ViewEncapsulation, ViewChild } from "@angular/core";
import { Table } from "primeng/table";
import { SelectItem } from "primeng/api";
import { Employee } from "../app/domain/employee";
import { DataService } from "../app/services/data.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  providers: [DataService],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {

  employeeDialog = false;

  employees: Employee[];

  employee = new Employee();

  statesList: SelectItem[];

  @ViewChild("dt")
  table: Table;

  constructor(private service: DataService) { }

  ngOnInit() {
    this.loadProducts();

    this.statesList = [
      { label: "Программист", value: "Программист" },
      { label: "Менеджер", value: "Менеджер" },
      { label: "Директор", value: "Директор" },
      { label: "Маркетолог", value: "Маркетолог" },
      { label: "Бухгалтер", value: "Бухгалтер" },
      { label: "Дизайнер", value: "Дизайнер" },
      { label: "Финансовый директор", value: "Финансовый директор" }
    ];
  }

  loadProducts() {
    this.service.getEmployees().subscribe((data: Employee[]) => this.employees = data);
  }

  openNew() {
    this.employee = new Employee();
    this.employeeDialog = true;
  }

  edit(employee: Employee) {
    this.employee = { ...employee };
    this.employeeDialog = true;
  }

  delete(employee: Employee) {
    this.service.deleteEmployee(employee.id).subscribe(data => this.loadProducts());
  }

  hideDialog() {
    this.employeeDialog = false;
    this.employee = new Employee();
  }

  save() {
    if (this.employee.id == null) {
      this.service.createEmployee(this.employee).subscribe((data: Employee) => this.employees.push(data));
    } else {
      this.service.updateEmployee(this.employee).subscribe(x => this.loadProducts());
    }
    
    this.employeeDialog = false;
    this.employee = new Employee();
  }

  onRowSelect(event) {
    this.employee = event.data;
    this.employeeDialog = true;
  }
}

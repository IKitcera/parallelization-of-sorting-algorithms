import {Component, Injectable, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpService} from './http.service';
import {Sort} from './sort.model';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})

export class TaskComponent implements OnInit {

  unsortedArr: number[];
  bubbleS: Sort;
  shellS: Sort;

  formB = true;
  formS = true;
  constructor(private httpService: HttpService) {}

  ngOnInit(): void {
    this.getArr();
  }
  getArr(){
      this.httpService.GetArray().subscribe(x => {this.unsortedArr = x; });
  }
  bubbleSort(){
    this.httpService.BubbleSort().subscribe(x => {this.bubbleS = x; });
    this.formB = false;
  }
  shellSort(){
    this.httpService.ShellSort().subscribe(x => {this.shellS = x; });
    this.formS = false;
  }

  hideResults(){
    this.formB = true;
    this.formS = true;
  }
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-red-component',
  templateUrl: './red-component.component.html',
  styleUrls: ['./red-component.component.css']
})
export class RedComponentComponent implements OnInit {

  sousRouges: string[] = ["cramoisi", "écarlate", "cerise", "bordeaux","vermeil"];
  constructor() { }

  ngOnInit(): void {
  }

}

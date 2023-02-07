import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-red',
  templateUrl: './red.component.html',
  styleUrls: ['./red.component.css']
})
export class RedComponent implements OnInit {

  sousRouges : string[] = ["cramoisi", "écarlate", "cerise", "bordeaux","vermeil","HAHAHAHA"];
  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-jaune',
  templateUrl: './jaune.component.html',
  styleUrls: ['./jaune.component.css']
})
export class JauneComponent implements OnInit {
  [x: string]: any;

  legume : string | null = null;

  constructor(public route: ActivatedRoute) { }

  ngOnInit(): void {
    this.legume = this.route.snapshot.paramMap.get("legume");
  }

}

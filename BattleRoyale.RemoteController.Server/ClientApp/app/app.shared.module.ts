import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CommandComponent } from './components/command/command.component';
import { ClientService } from './services/client.service';
import { CommandAllComponent } from './components/commandAll/commandall.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CommandComponent,
        CommandAllComponent,
        FetchDataComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'command', component: CommandComponent  },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'commandall', component: CommandAllComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ClientService]
})
export class AppModuleShared {
}
